import { useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useLocalStorageWords } from "../../hooks/useLocalStorageWords";

export const useEditWordPageState = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const { getWordById } = useLocalStorageWords();
  
  const word = id ? getWordById(id) : undefined;

  useEffect(() => {
    if (id && !word) {
      navigate("/dictionary");
    }
  }, [id, word, navigate]);

  return {
    word,
    id
  };
};