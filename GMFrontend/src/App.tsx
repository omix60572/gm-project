import "./App.css";
import "./components/styles/MovieCard.css";
import "./components/styles/SearchBar.css";
import "./components/styles/TopMenuBar.css";
import "./components/styles/SelectedMovieDetails.css";
import AppContent from "./components/AppContent";

interface AppProps {
  body: HTMLElement;
}

function App({ body }: Readonly<AppProps>) {
  return <AppContent body={body} />;
}

export default App;
