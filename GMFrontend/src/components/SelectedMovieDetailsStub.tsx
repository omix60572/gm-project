function SelectedMovieDetailsStub() {
  return (
    <div className="selected-movie-wide-card-page-root-div">
      <div className="card mb-5 mt-4 selected-movie-wide-card-div">
        <div className="row g-0 selected-movie-wide-card-sceleton-item rounded-start-2">
          <div className="col-md-3">
            <div className="selected-movie-skeleton-poster card-img" />
          </div>
          <div className="col-md-9">
            <div className="card-body ps-4 pt-4">
              <div className="selected-movie-skeleton-line selected-movie-skeleton-title mb-3 rounded-1" />
              <div className="selected-movie-skeleton-line mb-2 rounded-1" />
              <div className="selected-movie-skeleton-line mb-2 rounded-1" />
              <div className="selected-movie-skeleton-line mb-2 rounded-1" />
              <div className="selected-movie-skeleton-line selected-movie-skeleton-short mb-3 rounded-1" />
              <div className="selected-movie-skeleton-line selected-movie-skeleton-shorter rounded-1" />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default SelectedMovieDetailsStub;
