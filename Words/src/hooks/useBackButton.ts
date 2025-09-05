import { useNavigate, useLocation } from "react-router-dom";

export const useBackButton = () => {
  const navigate = useNavigate();
  const location = useLocation();

  const handleBack = () => {
    const currentPath = location.pathname;

    const backPaths: Record<string, string> = {
      "/new-word": "/dictionary",
      "/edit-word": "/dictionary",
      "/test": "/",
      "/dictionary": "/",
    };

    const backPath = Object.keys(backPaths).find((path) =>
      currentPath.startsWith(path)
    );

    if (backPath) {
      navigate(backPaths[backPath]);
    } else {
      navigate(-1);
    }
  };

  return {
    handleBack
  };
};