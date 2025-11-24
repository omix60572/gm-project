import { useEffect, useState } from "react";
import MoviesList from "./MoviesList";
import SearchBar from "./SearchBar";
import type MovieCardModel from "../models/MovieCardModel";
import { getPopularMovies } from "../services/MoviesApiService";

interface MoviesViewProps {
  searchPlaceholder?: string;
}

function MoviesView({ searchPlaceholder }: Readonly<MoviesViewProps>) {
  const [movies, setMovies] = useState<MovieCardModel[]>([]);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(true);

  // Second param just empty arr, for single call only on component creation (render)
  useEffect(() => {
    const loadPopularMovies = async () => {
      try {
        const popularMoviesResponse: MovieCardModel[] =
          await getPopularMovies();

        if (
          popularMoviesResponse !== null &&
          popularMoviesResponse !== undefined
        )
          setMovies(popularMoviesResponse);
      } catch (e) {
        console.log(e);
        setError("Falied to load movies...");
      } finally {
        setLoading(false);
      }
    };

    loadPopularMovies();
  }, []);

  return (
    <>
      <SearchBar placeholder={searchPlaceholder} />
      <MoviesList movies={movies} />
    </>
  );
}

export default MoviesView;
