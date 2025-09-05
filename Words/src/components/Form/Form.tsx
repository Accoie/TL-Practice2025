import { Box, Button, Stack, TextField } from "@mui/material";
import { useForm } from '../../hooks/useForm.ts';

type FormProps = {
  mode: 'create' | 'edit';
  initialRussian?: string;
  initialEnglish?: string;
  wordId?: string;
};

export const Form = (props: FormProps) => {
  const {
    russian,
    english,
    isValid,
    setRussian,
    setEnglish,
    handleSave,
    handleCancel
  } = useForm(props);

  const fields = [
    { type: "russian", label: "Слово на русском языке" },
    { type: "english", label: "Перевод на английский язык" },
  ];

  return (
    <Box>
      <form onSubmit={handleSave}>
        <Stack spacing={3}>
          {fields.map((field) => (
            <TextField
              key={field.type}
              label={field.label}
              variant="outlined"
              fullWidth
              value={field.type === "russian" ? russian : english}
              onChange={(e) =>
                field.type === "russian"
                  ? setRussian(e.target.value)
                  : setEnglish(e.target.value)
              }
              required
            />
          ))}

          <Stack spacing={2} direction="row" justifyContent="flex-end">
            <Button
              variant="contained"
              type="submit"
              disabled={!isValid}
            >
              Сохранить
            </Button>
            <Button variant="outlined" onClick={handleCancel}>
              Отменить
            </Button>
          </Stack>
        </Stack>
      </form>
    </Box>
  );
};