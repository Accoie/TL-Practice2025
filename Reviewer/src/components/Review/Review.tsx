import styles from "./Review.module.css";

type ReviewProps = {
  name: string;
  review: string;
  average: number;
};

export const Review = ({ name, review, average }: ReviewProps) => {
  return (
    <div className={styles.reviewCard}>
      <img
        className={styles.reviewAvatar}
        src="src/assets/avatars/avatar.png"
      ></img>
      <div className={styles.reviewHeader}>
        <div className={styles.reviewHeaderWrapper}>
          <h3 className={styles.reviewerName}>{name}</h3>
          <p className={styles.reviewText}>{review}</p>
        </div>
        <div className={styles.rating}>
          <span className={styles.ratingValue}>{average.toFixed(2)}/5</span>
        </div>
      </div>
    </div>
  );
};