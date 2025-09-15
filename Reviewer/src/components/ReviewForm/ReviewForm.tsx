import type { ReviewObject } from "../../hooks/ReviewObject";
import { GradesList } from "../GradesList/GradesList";
import styles from "./ReviewForm.module.css";
import { useState, useRef, useEffect } from "react";

type ReviewFormProps = {
  setReviews: (reviews: ReviewObject[] | ((prev: ReviewObject[]) => ReviewObject[])) => void;
}

export const ReviewForm = ({ setReviews }: ReviewFormProps) => {
  const [average, setAverage] = useState(0);
  const [name, setName] = useState("");
  const [reviewText, setReviewText] = useState("");
  const [isSuccess, setIsSuccess] = useState(false);
  const textAreaRef = useRef<HTMLTextAreaElement>(null);

  useEffect(() => {
    adjustTextareaHeight();
  }, [reviewText]);

  const handleSubmit = () => {
    if (average === 0 || name === "" || reviewText === "") {
      console.log("Все поля обязательны для заполнения");
      return;
    }

    const reviewObj: ReviewObject = {
      average: average,
      name: name,
      description: reviewText,
    };

    setReviews(prevReviews => [...prevReviews, reviewObj]);

    setIsSuccess(true);
    
    setTimeout(() => {
      setName("");
      setReviewText("");
      setAverage(0);
      setIsSuccess(false);
    }, 2000);
  };

  const adjustTextareaHeight = () => {
    const textarea = textAreaRef.current;
    if (textarea) {
      textarea.style.height = "auto";
      textarea.style.height = textarea.scrollHeight + "px";
    }
  };

  return (
    <form className={styles.reviewForm} onSubmit={(e) => e.preventDefault()}>
      <div className={styles.reviewFormWrapper}>
        <h3 className={styles.formTitle}>
          Помогите нам сделать процесс бронирования лучше
        </h3>

        <GradesList onAverageChange={setAverage} />

        <div className={styles.inputContainer}>
          <input
            type="text"
            id="name"
            className={`${styles.nameInput} ${isSuccess ? styles.success : ""}`}
            placeholder="Как вас зовут?"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
          <label htmlFor="name" className={styles.inputLabel}>
            Имя*
          </label>
        </div>

        <textarea
          ref={textAreaRef}
          className={`${styles.reviewInput} ${isSuccess ? styles.success : ""}`}
          placeholder="Напишите, что понравилось, что было непонятно"
          value={reviewText}
          onChange={(e) => setReviewText(e.target.value)}
          required
        />

        <button
          type="button"
          className={styles.submitButton}
          onClick={handleSubmit}
          disabled={average === 0}
        >
          {isSuccess ? "✓ Отправлено" : "Отправить"}
        </button>
      </div>
    </form>
  );
};