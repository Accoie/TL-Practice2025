import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";
import MenuBookOutlinedIcon from "@mui/icons-material/MenuBookOutlined";
import CloseOutlinedIcon from "@mui/icons-material/CloseOutlined";
import { Button, Card, CardContent, Typography } from "@mui/material";
import styles from "./ResultPage.module.scss";
import { useResultPageState } from "./ResultPage.state";

export const ResultPage = () => {
  const { correctCount, totalCount, handleRetry, goToHome } =
    useResultPageState();

  return (
    <Card className={styles.resultCard}>
      <CardContent className={styles.cardContent}>
        <Typography variant="h5" gutterBottom className={styles.title}>
          Результаты проверки
        </Typography>

        {totalCount === 0 ? (
          <Typography variant="body1" className={styles.noData}>
            Нет данных о результатах теста
          </Typography>
        ) : (
          <>
            <Typography
              variant="body1"
              className={`${styles.resultItem} ${styles.correct}`}
            >
              <CheckCircleOutlineIcon className={styles.icon} />
              Правильных ответов: {correctCount}
            </Typography>
            <Typography
              variant="body1"
              className={`${styles.resultItem} ${styles.incorrect}`}
            >
              <CloseOutlinedIcon className={styles.icon} />
              Неправильных ответов: {totalCount - correctCount}
            </Typography>
            <Typography
              variant="body1"
              className={`${styles.resultItem} ${styles.total}`}
            >
              <MenuBookOutlinedIcon className={styles.icon} />
              Всего слов: {totalCount}
            </Typography>
          </>
        )}

        <div className={styles.buttonGroup}>
          <Button
            sx={{
              backgroundColor: "#308cc9ff",
              fontWeight: 600,
              textTransform: "none",
              "&:hover": {
                backgroundColor: "#75c0f1ff",
                boxShadow: "0 4px 12px rgba(39, 138, 174, 0.3)",
              },
              "&:disabled": {
                backgroundColor: "#bdc3c7",
                color: "#7f8c8d",
              },
            }}
            variant="contained"
            onClick={handleRetry}
            className={styles.retryButton}
          >
            Пройти ещё раз
          </Button>
          <Button
            variant="outlined"
            onClick={goToHome}
            className={styles.homeButton}
          >
            На главную
          </Button>
        </div>
      </CardContent>
    </Card>
  );
};
