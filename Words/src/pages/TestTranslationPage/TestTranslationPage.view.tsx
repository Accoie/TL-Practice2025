import {
  Box,
  Button,
  Card,
  CardContent,
  Typography,
  LinearProgress,
  Stack,
  Paper,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  OutlinedInput,
} from "@mui/material";
import { BackButton } from "../../components/buttons/BackButton/BackButton";
import { useTestTranslationState } from "./TestTranslationPage.state";
import styles from './TestTranslationPage.module.scss';
import { useState } from 'react';

export const TestTranslationPage = () => {
  const {
    selectedWords,
    currentIndex,
    options,
    selectedOption,
    progress,
    handleOptionChange,
    handleNext,
  } = useTestTranslationState();

  const [isSelectFocused, setIsSelectFocused] = useState(false);

  const currentWord = selectedWords[currentIndex];

  const handleSelectFocus = () => {
    setIsSelectFocused(true);
  };

  const handleSelectBlur = () => {
    setIsSelectFocused(false);
  };

  const selectClassName = `${styles.selectRoot} ${isSelectFocused ? styles.selectFocused : ''}`;

  return (
    <Box className={styles.container}>
      <Stack direction="row" alignItems="center" spacing={2} className={styles.header}>
        <BackButton />
        <Typography variant="h4" className={styles.title}>
          Тест на перевод
        </Typography>
      </Stack>

      <Typography variant="subtitle1" className={styles.subtitle}>
        Вопрос №{currentIndex + 1} из {selectedWords.length}
      </Typography>

      <Paper elevation={2} className={styles.paper}>
        <LinearProgress
          variant="determinate"
          value={progress}
          className={styles.progress}
          classes={{ bar: styles.progressBar }}
        />

        <Card className={styles.card}>
          <CardContent className={styles.cardContent}>
            <Typography 
              variant="h6"  
              align="center" 
              className={styles.instruction}
            >
              Выберите правильный перевод для слова:
            </Typography>
            
            <Typography 
              variant="h4" 
              align="center" 
              className={styles.word}
            >
              {currentWord?.russian ?? ""}
            </Typography>

            <FormControl fullWidth variant="outlined" className={styles.formControl}>
              <InputLabel 
                id="translation-select-label"
                className={styles.inputLabel}
              >
                Варианты перевода
              </InputLabel>
              <Select
                labelId="translation-select-label"
                value={selectedOption}
                onChange={handleOptionChange}
                onFocus={handleSelectFocus}
                onBlur={handleSelectBlur}
                displayEmpty
                className={selectClassName}
                input={<OutlinedInput classes={{ notchedOutline: styles.selectOutline }} />}
              >
                <MenuItem value="">
                  <em>— выберите вариант —</em>
                </MenuItem>
                {options.map((option, index) => (
                  <MenuItem 
                    key={index} 
                    value={option}
                    className={styles.menuItem}
                  >
                    {option}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </CardContent>
        </Card>

        <Box className={styles.buttonContainer}>
          <Button
            variant="contained"
            onClick={handleNext}
            disabled={!selectedOption}
            size="large"
            className={styles.button}
          >
            {currentIndex < selectedWords.length - 1 ? "Следующий вопрос" : "Завершить тест"}
          </Button>
        </Box>
      </Paper>
    </Box>
  );
};