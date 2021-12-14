import { api } from './api';
import { browserManager } from './browser';
import { createGetVideoResponseMessage, createTabChangedRequestMessage, createUpdateVideoResponseMessage, GetVideoRequestMessageType, UpdateVideoRequestMessageType } from './messages';
import { Message } from './models';

browserManager.addMessageEventListener(async (message: Message) => {
  console.log(`received message in background: ${message.type}`);
  switch (message.type) {
    case GetVideoRequestMessageType:
      await getVideoRequestMessageHandler(message);
      break;
    case UpdateVideoRequestMessageType:
      await updateVideoRequestMessageHandler(message);
      break;
    default:
      break;
  }
});

browserManager.addCurrentTabChangeEventListener(() => {
  const message = createTabChangedRequestMessage();
  browserManager.sendMessageToCurrentTab(message);
});

const getVideoRequestMessageHandler = async (message: Message) => {
  const videoId = message.payload;
  var video = await api.getVideo(videoId);
  const getVideoResponseMessage = createGetVideoResponseMessage(video);
  browserManager.sendMessageToCurrentTab(getVideoResponseMessage);
}

const updateVideoRequestMessageHandler = async (message: Message) => {
  const payload = message.payload;
  await api.updateVideo(payload.videoId, payload.isDislike);
  const updateVideoResponseMessage = createUpdateVideoResponseMessage(payload.isDislike);
  browserManager.sendMessageToCurrentTab(updateVideoResponseMessage);
}