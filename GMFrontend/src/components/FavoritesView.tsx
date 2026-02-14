import { useEffect, useState } from "react";
import MoviesList from "./MoviesList";
import SearchBar from "./SearchBar";
import type MovieCardModel from "../models/MovieCardModel";
import MoviesApiService from "../services/MoviesApiService";

interface FavoritesViewProps {
  searchPlaceholder?: string;
}

function FavoritesView({ searchPlaceholder }: Readonly<FavoritesViewProps>) {
  const [movies, setMovies] = useState<MovieCardModel[]>([]);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(true);
  const moviesApiService = MoviesApiService.getInstance();

  // Second param just empty arr, for single call only on component creation (render)
  useEffect(() => {
    const loadPopularMovies = async () => {
      try {
        const popularMoviesResponse: MovieCardModel[] =
          await moviesApiService.getPopularMovies(); // TODO: Replace API call to proper method call

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

export default FavoritesView;
