import MovieCardModel from "../models/MovieCardModel";
import MovieCard from "./MovieCard";

interface MoviesListProps {
  movies: MovieCardModel[];
}

function MoviesList({ movies }: Readonly<MoviesListProps>) {
  return (
    <div className="d-inline-block">
      {movies.map((movie) => (
        <MovieCard model={movie} key={movie.id} />
      ))}
    </div>
  );
}

export default MoviesList;
