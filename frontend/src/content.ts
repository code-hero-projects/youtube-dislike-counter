import { formatDislikes, getVideoId } from './utils';
import { browserManager } from './browser';
import { Message, Video } from './models';
import { createGetVideoRequestMessage, createUpdateVideoRequestMessage, GetVideoResponseMessageType, TabChangedMessageType, UpdateVideoResponseMessageType } from './messages';

let dislikeButton: any = null;
let dislikeText: any = null;
let oldVideoId: string = '';
let currentDislikes = 0;

browserManager.addMessageEventListener((message: Message) => {
  console.log(`received message in content: ${message.type}`);
  switch (message.type) {
    case GetVideoResponseMessageType:
      getVideoResponseMessageHandler(message);
      break;
    case UpdateVideoResponseMessageType:
      updateVideoResponseMessageHandler(message);
      break;
    case TabChangedMessageType:
      tabChangeMessageHandler();
      break;
    default:
      break;
  }
});

const getVideoResponseMessageHandler = (message: Message) => {
  const videoInfo = message.payload as Video;
  currentDislikes = videoInfo.dislikes;
  dislikeText.innerText = formatDislikes(videoInfo.dislikes);
};

const updateVideoResponseMessageHandler = (message: Message) => {
  const isDislike = message.payload;
  currentDislikes += isDislike ? 1 : -1;
  dislikeText.innerText = formatDislikes(currentDislikes);
};

const tabChangeMessageHandler = () => {
  const videoId = getVideoId();
  if (videoId.length == 0 || videoId === oldVideoId) {
    return;
  }
  oldVideoId = videoId;
  if (dislikeButton != null && dislikeText != null) {
    sendGetVideoMessage(videoId);
  } else {
    const waitUntilDislikeButton = setInterval(() => {
      if (document.querySelector('.force-icon-button')) {
        addDislikeButtonEventListener(videoId);
        sendGetVideoMessage(videoId);
        clearInterval(waitUntilDislikeButton);
      }
    }, 100);
  }
};

const addDislikeButtonEventListener = (videoId: string) => {
  dislikeButton = document.getElementsByClassName("style-scope ytd-menu-renderer force-icon-button")[1];
  dislikeText = dislikeButton.childNodes[0].childNodes[1] as HTMLElement;

  dislikeButton.addEventListener('click', () => {
    const currentClasses = dislikeButton.className;
    const isDislike = currentClasses.includes('style-default-active');
    const updateVideoMessage = createUpdateVideoRequestMessage(videoId, isDislike);
    browserManager.sendMessageToBackground(updateVideoMessage);
  });
};

const sendGetVideoMessage = (videoId: string) => {
  const getVideoMessage = createGetVideoRequestMessage(videoId);
  browserManager.sendMessageToBackground(getVideoMessage);
};