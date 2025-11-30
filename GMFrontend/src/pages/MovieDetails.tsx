import { useParams } from "react-router-dom";
import SelectedMovieDetails from "../components/SelectedMovieDetails";

function MovieDetails() {
  let { movieIdStr } = useParams();
  movieIdStr ??= "-1";

  return <SelectedMovieDetails movieId={Number.parseInt(movieIdStr)} />;
}

export default MovieDetails;
