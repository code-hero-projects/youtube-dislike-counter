import { Message } from '../models';

export interface IBrowserManager {
  sendMessageToBackground(message: Message): void;
  sendMessageToCurrentTab(message: Message): void;
  addMessageEventListener(callback: (message: any) => void): void;
  addCurrentTabChangeEventListener(callback: () => void): void;
}
