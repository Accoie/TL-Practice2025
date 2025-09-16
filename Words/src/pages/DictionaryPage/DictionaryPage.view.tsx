import {
  Stack,
  Box,
  Typography,
  Button,
  Table,
  TableContainer,
  Paper,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  IconButton,
  Menu,
  MenuItem,
} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import { BackButton } from "../../components/buttons/BackButton/BackButton.tsx";
import { useDictionaryPageState } from "./DictionaryPage.state.ts";
import styles from "./DictionaryPage.module.scss";

export const DictionaryPage = () => {
  const {
    words,
    anchorEl,
    open,
    handleAddNew,
    handleDelete,
    handleEdit,
    handleClose,
    handleOpen,
  } = useDictionaryPageState();

  return (
    <Box className={styles.dictionaryPage}>
      <Stack direction={"row"} className={styles.header}>
        <BackButton />
        <Typography variant="h3" className={styles.title}>
          Словарь
        </Typography>
      </Stack>

      <Button
        variant="contained"
        onClick={handleAddNew}
        className={styles.addButton}
        sx={{
          borderRadius: 2,
          backgroundColor: "#318eccff",
          fontWeight: 600,
          textTransform: "none",
          "&:hover": {
            backgroundColor: "#75c0f1ff",
            boxShadow: "0 4px 12px rgba(39, 138, 174, 0.3)",
          },
        }}
      >
        Добавить слово
      </Button>

      <TableContainer component={Paper} className={styles.tableContainer}>
        <Table>
          <TableHead className={styles.tableHead}>
            <TableRow>
              <TableCell className={styles.tableCell}>
                Слово на русском
              </TableCell>
              <TableCell className={styles.tableCell} align="center">
                Слово на английском
              </TableCell>
              <TableCell className={styles.tableCell} align="right">
                Действие
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody className={styles.tableBody}>
            {words.map((word) => (
              <TableRow key={word.id} className={styles.tableRow}>
                <TableCell className={styles.tableCell}>
                  {word.russian}
                </TableCell>
                <TableCell className={styles.tableCell} align="center">
                  {word.english}
                </TableCell>
                <TableCell
                  className={`${styles.tableCell} ${styles.actionCell}`}
                  align="right"
                >
                  <IconButton
                    onClick={(e) => handleOpen(e, word.id)}
                    className={styles.menuButton}
                  >
                    <MenuIcon />
                  </IconButton>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

      <Menu
        anchorEl={anchorEl}
        open={open}
        anchorOrigin={{ vertical: "top", horizontal: "left" }}
        transformOrigin={{ vertical: "top", horizontal: "left" }}
        onClose={handleClose}
        classes={{ paper: styles.menuPaper }}
      >
        <MenuItem onClick={handleEdit} className={styles.menuItem}>
          Редактировать
        </MenuItem>
        <MenuItem onClick={handleDelete} className={styles.menuItem}>
          Удалить
        </MenuItem>
      </Menu>
    </Box>
  );
};
