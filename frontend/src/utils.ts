const Thousand = 1000;
const TenThousand = 10000;
const HundredThousand = 1000000;
const Million = 1000000;
const TenMillion = 10000000;

const ThousandsIdentifier = 'K';
const MillionsIdentifier = 'M';

export const getVideoId = () => {
  if (!window.location.search) {
    return '';
  }
  var videoId = window.location.search.split('v=')[1];
  var endPosition = videoId.indexOf('&');
  if (endPosition == -1) {
    endPosition = videoId.length;
  }
  return videoId.substring(0, endPosition);
}

export const formatDislikes = (dislikes: number) => {
  if (dislikes > Thousand && dislikes < TenThousand) {
    return `${formatWithComma(dislikes, 2, true)} ${ThousandsIdentifier}`;
  } else if (dislikes >= TenThousand && dislikes < HundredThousand ) {
    return `${formatWithComma(dislikes, 2, false)} ${ThousandsIdentifier}`;
  } else if (dislikes >= HundredThousand && dislikes < Million) {
    return `${formatWithComma(dislikes, 3, false)} ${MillionsIdentifier}`;
  } else if (dislikes >= Million && dislikes < TenMillion) {
    return `${formatWithComma(dislikes, 2, true)} ${MillionsIdentifier}`;
  } else if (dislikes >= TenMillion) {
    return `${formatWithComma(dislikes, 2, false)} ${MillionsIdentifier}`;
  } else {
    return dislikes.toString();
  }
}

const formatWithComma = (dislikes: number, numbersToConsider: number, withComma: boolean) => {
  let dislikesNumber = dislikes.toString().substring(0, numbersToConsider);
  if (withComma) {
    dislikesNumber = `${dislikesNumber[0]},${dislikesNumber.substring(1)}`;
  }
  return dislikesNumber;
}