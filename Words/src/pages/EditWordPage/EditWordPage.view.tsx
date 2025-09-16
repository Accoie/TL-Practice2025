import { Box, Typography, Stack } from "@mui/material";
import { BackButton } from "../../components/buttons/BackButton/BackButton";
import { Form } from "../../components/Form/Form";
import { useEditWordPageState } from './EditWordPage.state';

export const EditWordPage = () => {
  const { word, id } = useEditWordPageState();

  if (!word) {
    return (
      <Box sx={{ textAlign: "center", padding: "20px" }}>
        <Typography variant="h4">Слово не найдено</Typography>
      </Box>
    );
  }

  return (
    <Box sx={{ textAlign: "left", width: "100%", padding: "20px" }}>
      <Stack direction={"row"} spacing={2} mb={3}>
        <BackButton />
        <Typography variant="h3" sx={{ color: "#364963" }}>
          Редактировать слово
        </Typography>
      </Stack>
      <Form
        mode="edit"
        wordId={id}
        initialRussian={word.russian}
        initialEnglish={word.english}
      />
    </Box>
  );
};