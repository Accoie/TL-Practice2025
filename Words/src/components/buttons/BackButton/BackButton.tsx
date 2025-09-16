import { Button } from "@mui/material";
import styles from './BackButton.module.scss';
import { useBackButton } from "../../../hooks/useBackButton";

export const BackButton = () => {
  const {handleBack} = useBackButton();

  return (
    <Button
      variant="outlined"
      onClick={handleBack}
      className={styles.backButton}
    >
      {"<"}
    </Button>
  );
};