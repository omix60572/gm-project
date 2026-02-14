import "./App.css";
import "./components/styles/MovieCard.css";
import "./components/styles/SearchBar.css";
import "./components/styles/TopMenuBar.css";
import "./components/styles/SelectedMovieDetails.css";
import AppContent from "./components/AppContent";
import AuthComponent from "./components/AuthComponent";

interface AppProps {
  body: HTMLElement;
}

function App({ body }: Readonly<AppProps>) {
  return (
    <AuthComponent>
      <AppContent body={body} />
    </AuthComponent>
  );
}

export default App;
