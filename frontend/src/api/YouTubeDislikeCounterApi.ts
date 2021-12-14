import { Video } from '../models';
import { YouTubeDislikeCounterApiUrl } from './consts'
import { IYouTubeDislikeCounterApi } from './IYouTubeDislikeCounterApi';

export class YouTubeDislikeCounterApi implements IYouTubeDislikeCounterApi {
  async getVideo(id: string): Promise<Video> {
    const url = `${YouTubeDislikeCounterApiUrl}${id}`;
    return fetch(url).then(response => response.json());
  }

  async updateVideo(id: string, isDislike: boolean): Promise<void> {
    const url = `${YouTubeDislikeCounterApiUrl}${id}`;
    return fetch(url, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ isDislike })
    })
    .then(response => response.json());
  }
}