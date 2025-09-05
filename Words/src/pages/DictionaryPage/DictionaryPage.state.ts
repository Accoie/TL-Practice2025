import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useLocalStorageWords } from "../../hooks/useLocalStorageWords";

export const useDictionaryPageState = () => {
  const { words, deleteWord } = useLocalStorageWords();
  const navigate = useNavigate();

  const [anchorEl, setAnchorEl] = useState<undefined | HTMLElement>(undefined);
  const [selectedWordId, setSelectedWordId] = useState<string | undefined>(
    undefined
  );
  const open = Boolean(anchorEl);

  const handleAddNew = () => {
    navigate("/new-word");
  };

  const handleDelete = () => {
    if (selectedWordId) {
      deleteWord(selectedWordId);
    }

    handleClose();
  };

  const handleOpen = (event: React.MouseEvent<HTMLElement>, wordId: string) => {
    setAnchorEl(event.currentTarget);
    setSelectedWordId(wordId);
  };

  const handleClose = () => {
    setAnchorEl(undefined);
    setSelectedWordId(undefined);
  };

  const handleEdit = () => {
    if (selectedWordId) {
      navigate(`/edit-word/${selectedWordId}`);
    }

    handleClose();
  };

  return {
    words,
    anchorEl,
    open,
    handleAddNew,
    handleDelete,
    handleOpen,
    handleClose,
    handleEdit,
  };
};
