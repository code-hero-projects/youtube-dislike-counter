import { Message, Video } from '../models';
import { GetVideoResponseMessageType, GetVideoRequestMessageType, UpdateVideoRequestMessageType, UpdateVideoResponseMessageType, TabChangedMessageType } from './messageTypes';

export const createGetVideoRequestMessage = (videoId: string): Message => createMessage(GetVideoRequestMessageType, videoId);

export const createGetVideoResponseMessage = (video: Video): Message => createMessage(GetVideoResponseMessageType, video);

export const createUpdateVideoRequestMessage = (videoId: string, isDislike: boolean): Message => createMessage(UpdateVideoRequestMessageType, { videoId, isDislike });

export const createUpdateVideoResponseMessage = (isDislike: boolean): Message => createMessage(UpdateVideoResponseMessageType, isDislike);

export const createTabChangedRequestMessage = (): Message => createMessage(TabChangedMessageType, { });

const createMessage = (type: string, payload: any): Message => {
  return { type, payload };
};