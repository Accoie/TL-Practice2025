import { Box, Stack, Typography } from "@mui/material";
import { BackButton } from "../../components/buttons/BackButton/BackButton";
import { Form } from "../../components/Form/Form";

export const AddWordPage = () => {
  return (
    <Box>
      <Stack direction="row">
        <BackButton />
        <Typography variant="h3" sx={{ color: "#2c3e57ff" }}>
          Добавление слова
        </Typography>
      </Stack>

      <Form mode="create" />
    </Box>
  );
};