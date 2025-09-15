import AngryFace   from '../assets/icons/twemoji_angry-face.svg?react';
import SlightlyFrowning from '../assets/icons/twemoji_slightly-frowning-face.svg?react';
import NeutralFace from '../assets/icons/twemoji_neutral-face.svg?react';
import SlightlySmiling from '../assets/icons/twemoji_slightly-smiling-face.svg?react';
import GrinningFace from '../assets/icons/twemoji_grinning-face-with-big-eyes.svg?react';

type SmileIconProps = {
  value: number;
}

export const SmileIcon = (smileIconProps: SmileIconProps) => {
  const props: React.SVGProps<SVGSVGElement> = { 
    width: 16, 
    height: 16, 
    className: 'smiley-icon' 
  };
  
  switch (smileIconProps.value) {
    case 1:
      return <AngryFace {...props} />;
    case 2:
      return <SlightlyFrowning {...props} />;
    case 3:
      return <NeutralFace {...props} />;
    case 4:
      return <SlightlySmiling {...props} />;
    case 5:
      return <GrinningFace {...props} />;
    default:
      return null
  }
};