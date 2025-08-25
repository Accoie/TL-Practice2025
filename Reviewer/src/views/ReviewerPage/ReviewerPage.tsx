import { ReviewForm } from "../../components/ReviewForm/ReviewForm"
import { ReviewList } from "../../components/ReviewList/ReviewList"
import styles from "./ReviewerPage.module.css"

export const ReviewerPage = () => {
  return(
    <div className={styles.reviewerPage}>
      <div className={styles.reviewFormWrapper}>
        <ReviewForm></ReviewForm>
      </div>
      <ReviewList></ReviewList>
    </div>
  )
}