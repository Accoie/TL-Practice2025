import styles from "./ReviewList.module.css";
import { Review } from "../Review/Review";
type ReviewObject = {
  name: string;
  description: string;
  average: number;
};

export const ReviewList = () => {
  const getReviewsFromLocalStorage = (): ReviewObject[] => {
    try {
      return JSON.parse(localStorage.getItem("reviews") || "[]");
    } catch (error) {
      console.error("Ошибка при чтении отзывов:", error);
      return [];
    }
  };

  const reviews = getReviewsFromLocalStorage();

  return (
    <div className={styles.reviewList}>
      <div className={styles.reviewsContainer}>
        {reviews.map((review, index) => (
          <Review
            key={index}
            name={review.name}
            review={review.description}
            average={review.average}
          ></Review>
        ))}
      </div>
    </div>
  );
};