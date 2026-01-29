import { Route, Routes } from "react-router-dom";
import "./App.css";
import "./components/styles/MovieCard.css";
import "./components/styles/SearchBar.css";
import "./components/styles/TopMenuBar.css";
import "./components/styles/SelectedMovieDetails.css";
import Home from "./pages/Home";
import Favorites from "./pages/Favorites";
import TopMenuBar from "./components/TopMenuBar";
import Footer from "./components/Footer";
import MovieDetails from "./pages/MovieDetails";
import { localStorageService } from "./services/LocalStorageService";

interface AppProps {
  body: HTMLElement;
}

function App({ body }: Readonly<AppProps>) {
  const themeValueKey = "data-bs-theme";

  const currentTheme = localStorageService.getTheme();
  body.setAttribute(
      themeValueKey,
      currentTheme
    );

  const switchTheme = () => {
    const currentMode = body.getAttribute(themeValueKey);
    const newColorMode = currentMode === 'light' ? 'dark' : 'light';
    localStorageService.saveTheme(newColorMode);

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

export default App;
