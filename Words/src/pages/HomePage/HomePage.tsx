import { Box, Button, Stack, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import styles from "./HomePage.module.scss";

export const HomePage = () => {
  const navigate = useNavigate();

  return (
    <Stack direction={"row"} className={styles.homePage}>
      <Box>
        <Typography variant="h3" className={styles.title}>
          Выберите режим
        </Typography>
        <div className={styles.buttonContainer}>
          <Button
            variant="contained"
            onClick={() => navigate("/dictionary")}
            className={styles.primaryButton}
            sx={{
              borderRadius: 2,
              backgroundColor: "#3498db",
              fontWeight: 600,
              textTransform: "none",
              "&:hover": {
                backgroundColor: "#75c0f1ff", 
                boxShadow: "0 4px 12px rgba(39, 138, 174, 0.3)"
              },
            }}
          >
            Заполнить словарь
          </Button>
          <Button
            variant="outlined"
            onClick={() => navigate("/test")}
            className={styles.secondaryButton}
            sx={{
              borderWidth: "2px",
              borderColor: "#359dff32",
              "&:hover": {
                borderColor: "#2b85e5d0",
                backgroundColor: "rgba(53, 178, 255, 0.08)",
              },
            }}
          >
            Проверить знания
          </Button>
        </div>
      </Box>
    </Stack>
  );
};
