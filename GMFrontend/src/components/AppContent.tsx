import { Route, Routes } from "react-router-dom";
import TopMenuBar from "./TopMenuBar";
import Home from "../pages/Home";
import MovieDetails from "../pages/MovieDetails";
import Favorites from "../pages/Favorites";
import Footer from "./Footer";
import LocalStorageService from "../services/LocalStorageService";
import { LocalStorageThemeKey } from "../common/LocalStorageKeys";

interface AppContentProps {
  body: HTMLElement;
}

function AppContent({ body }: Readonly<AppContentProps>) {
  const themeValueKey = "data-bs-theme";
  const localStorageService = LocalStorageService.getInstance();

  const currentTheme = localStorageService.getValue(LocalStorageThemeKey);
  if (currentTheme !== null) {
    body.setAttribute(
      themeValueKey,
      currentTheme
    );
  }

  const switchTheme = () => {
    const currentMode = body.getAttribute(themeValueKey);
    const newColorMode = currentMode === "light" ? "dark" : "light";
    localStorageService.saveValue(LocalStorageThemeKey, newColorMode);

    body.setAttribute(
      themeValueKey,
      newColorMode
    );
  };

  return (
    <>
      <TopMenuBar switchTheme={switchTheme} />
      <main>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/favorites" element={<Favorites />} />
          <Route path="/moviedetails/:movieId" element={<MovieDetails />} />
        </Routes>
      </main>
      <Footer />
    </>
  );
}

export default AppContent;
