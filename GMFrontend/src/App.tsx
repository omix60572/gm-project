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

interface AppProps {
  body: HTMLElement;
}

function App({ body }: Readonly<AppProps>) {
  const themeValueKey = "data-bs-theme";

  // TODO: Init theme mode

  const switchTheme = () => {
    const currentMode = body.getAttribute(themeValueKey);
    body.setAttribute(
      themeValueKey,
      currentMode === "light" ? "dark" : "light"
    );

    // TODO: Save theme mode
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
