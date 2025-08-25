import { GradesList } from "../GradesList/GradesList";
import styles from "./ReviewForm.module.css";
import { useState, useRef, useEffect } from "react";

type ReviewObject = {
  name: string;
  description: string;
  average: number;
};

export const ReviewForm = () => {
  const [average, setAverage] = useState(0);
  const [name, setName] = useState("");
  const [reviewText, setReviewText] = useState("");
  const textAreaRef = useRef<HTMLTextAreaElement>(null);

  const loadAllToLocalStorage = () => {
    const reviewObj: ReviewObject = {
      average: average,
      name: name,
      description: reviewText,
    };

    if (
      reviewObj.name === "" ||
      reviewObj.average === 0 ||
      reviewObj.description === ""
    ) {
      console.log("Review fields cannot be empty");

      return;
    }

    const existingReviews = JSON.parse(localStorage.getItem("reviews") || "[]");

    const updatedReviews = [...existingReviews, reviewObj];

    localStorage.setItem("reviews", JSON.stringify(updatedReviews));

    setName("");
    setReviewText("");
    setAverage(0);

    alert("Отзыв успешно сохранен!");
  };
  const adjustTextareaHeight = () => {
      const textarea = textAreaRef.current;
      if (textarea) {
        textarea.style.height = 'auto';
        textarea.style.height = textarea.scrollHeight + 'px';
      }
    };
  useEffect(()=>{adjustTextareaHeight()},[reviewText])

  return (
    <form className={styles.reviewForm}>
      <div className={styles.reviewFormWrapper}>
        <h3 className={styles.formTitle}>
          Помогите нам сделать процесс бронирования лучше
        </h3>
        <GradesList onAverageChange={setAverage}></GradesList>

        <div className={styles.inputContainer}>
          <input
            type="text"
            id="name"
            className={styles.nameInput}
            placeholder="Как вас зовут?"
            onChange={(e) => setName(e.target.value)}
            required
          />
          <label htmlFor="name" className={styles.inputLabel}>
            Имя*
          </label>
        </div>

        <textarea
          ref={textAreaRef}
          className={styles.reviewInput}
          placeholder="Напишите, что понравилось, что было непонятно"
          onChange={(e) => setReviewText(e.target.value)}
          required
        />

        <button
          type="submit"
          className={styles.submitButton}
          onClick={() => { 
            if(average === 0) return;
            loadAllToLocalStorage();
          }}
        >
          Отправить
        </button>
      </div>
    </form>
  );
};
