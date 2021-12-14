import { Message } from '../models';
import { IBrowserManager } from './IBrowserManager';

export class ChromeBrowserManager implements IBrowserManager {
  sendMessageToBackground(message: Message): void {
    console.log(`send message to background: ${message.type}`);
    chrome.runtime.sendMessage(message);
  }

  sendMessageToCurrentTab(message: Message): void {
    chrome.tabs.query({active: true, currentWindow: true}, tabs => {
      console.log(`send message to current tab: ${message.type}`);
      console.log(tabs[0]);
      chrome.tabs.sendMessage(tabs[0].id!, message);
    });
  }

  addCurrentTabChangeEventListener(callback: () => void): void {
    chrome.tabs.onUpdated.addListener((tabId, changeInfo, tab) => {
      if(changeInfo && changeInfo.status == "complete") {
        callback();
      }
    });
  }
  
  addMessageEventListener(callback: (message: Message) => void): void {
    chrome.runtime.onMessage.addListener(callback);
  }
}