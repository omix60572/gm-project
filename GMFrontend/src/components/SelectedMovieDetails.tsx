interface SelectedMovieDetailsProps {
  movieId: number;
}

function SelectedMovieDetails({ movieId }: SelectedMovieDetailsProps) {
  return (
    <div className="selected-movie-wide-card-page-root-div">
      <div className="selected-movie-details-top-buttons-div pt-4">
        <button
          type="button"
          className="btn btn-primary"
          onClick={() => {
            globalThis.history.go(-1);
          }}
        >
          <i className="bi bi-arrow-left me-1"></i> Go back
        </button>
      </div>
      <div className="card mb-5 mt-4 selected-movie-wide-card-div">
        <div className="row g-0">
          <div className="col-md-4">
            <img
              src="https://img.ixbt.site/live/images/original/29/80/01/2025/06/08/41f30ea243.webp"
              className="img-fluid rounded-start"
              alt="."
            />
          </div>
          <div className="col-md-8">
            <div className="card-body ps-4 pt-4">
              <h3 className="card-title pb-3">Побег из Шоушенка</h3>
              <p className="card-text">
                Мужчина оказывается в жестокой тюрьме за преступление, которого
                он, возможно, не совершал. Здесь царят страх и насилие, а
                выживают лишь те, кто умеет приспосабливаться.
              </p>
              <p className="card-text">
                <small className="text-body-secondary">Год выпуска: 1994</small>
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default SelectedMovieDetails;
