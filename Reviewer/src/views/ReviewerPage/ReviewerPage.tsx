import { ReviewForm } from "../../components/ReviewForm/ReviewForm"
import { ReviewList } from "../../components/ReviewList/ReviewList"
import type { ReviewObject } from "../../hooks/ReviewObject";
import { useLocalStorage } from "../../hooks/useLocalStorage";
import styles from "./ReviewerPage.module.css"

export const ReviewerPage = () => {
  const [reviews, setReviews] = useLocalStorage<ReviewObject[]>('reviews', []);
  
  return(
    <div className={styles.reviewerPage}>
      <div className={styles.reviewFormWrapper}>
        <ReviewForm setReviews={setReviews}/>
      </div>
      <ReviewList reviews={reviews}/>
    </div>
  )
}