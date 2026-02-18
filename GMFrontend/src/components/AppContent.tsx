import { Route, Routes } from "react-router-dom";
import TopMenuBar from "./TopMenuBar";
import Home from "../pages/Home";
import MovieDetails from "../pages/MovieDetails";
import Favorites from "../pages/Favorites";
import Footer from "./Footer";
import LocalStorageService from "../services/LocalStorageService";
import { LocalStorageThemeKey } from "../common/LocalStorageKeys";
import { ThemeValueDark, ThemeValueLight, ThemeAttributeValue } from "../common/CommonConst";

interface AppContentProps {
  body: HTMLElement;
}

function AppContent({ body }: Readonly<AppContentProps>) {
  const localStorageService = LocalStorageService.getInstance();

  const currentTheme = localStorageService.getValue(LocalStorageThemeKey);
  if (currentTheme !== null) {
    body.setAttribute(
      ThemeAttributeValue,
      currentTheme
    );
  }

  const switchTheme = () => {
    const currentMode = body.getAttribute(ThemeAttributeValue);
    const newColorMode = currentMode === ThemeValueLight ? ThemeValueDark : ThemeValueLight;
    localStorageService.saveValue(LocalStorageThemeKey, newColorMode);

    body.setAttribute(
      ThemeAttributeValue,
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
