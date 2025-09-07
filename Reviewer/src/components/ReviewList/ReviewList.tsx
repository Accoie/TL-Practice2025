import styles from "./ReviewList.module.css";
import { Review } from "../Review/Review";
import type { ReviewObject } from "../../hooks/ReviewObject";

type ReviewListProps = {
  reviews: ReviewObject[];
}

export const ReviewList = ({ reviews }: ReviewListProps) => {
  return (
    <div className={styles.reviewList}>
      <div className={styles.reviewsContainer}>
        {reviews.map((review, index) => (
          <Review
            key={index}
            name={review.name}
            review={review.description}
            average={review.average}
          />
        ))}
      </div>
    </div>
  );
};