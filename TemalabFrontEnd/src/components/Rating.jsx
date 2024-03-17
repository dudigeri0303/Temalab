import { array } from "prop-types";
import "../App.css";

export default function Rating() {
    const avarageRating = (avarageNumber) => {
        const fullStar = Math.floor(avarageNumber);
        if((avarageNumber - fullStar) > 0.5){
            return fullStar +1;
        }
        else{
            return fullStar;
        }
    }

    const stars = [];
    for (let i = 0; i < avarageRating; i++){
        stars.push("★");
    }
  return (
    <>
    <div>
        {stars}
    </div>
</>
);
}