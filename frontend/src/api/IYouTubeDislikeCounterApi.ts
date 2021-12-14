import { Video } from '../models';

export interface IYouTubeDislikeCounterApi {
  getVideo(id: string): Promise<Video>;
  updateVideo(id: string, isDislike: boolean): Promise<void>;
}