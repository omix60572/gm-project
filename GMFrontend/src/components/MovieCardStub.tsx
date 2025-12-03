function MovieCardStub() {
  return (
    <div className="movie-card card shadow mt-4 ms-4 movie-card-skeleton rounded-top">
      <div className="movie-card-img-div movie-card-skeleton-block rounded-top" />
      <div className="card-body">
        <div className="movie-card-skeleton-line movie-card-skeleton-title mb-3 rounded-1" />
        <div className="movie-card-skeleton-line mb-1 rounded-1" />
        <div className="movie-card-skeleton-line mb-1 rounded-1" />
        <div className="movie-card-skeleton-line mb-1 rounded-1" />
        <div className="movie-card-skeleton-line movie-card-skeleton-short mb-3 rounded-1" />
        <div className="d-flex mt-3">
          <div className="movie-card-skeleton-button me-2 rounded-1" />
          <div className="movie-card-skeleton-button me-2 rounded-1" />
          <div className="movie-card-skeleton-button rounded-1" />
        </div>
      </div>
    </div>
  );
}

export default MovieCardStub;
