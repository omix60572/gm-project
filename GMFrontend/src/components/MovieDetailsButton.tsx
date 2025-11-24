import OverlayTrigger from "react-bootstrap/esm/OverlayTrigger";
import type MovieCardModel from "../models/MovieCardModel";
import Button from "react-bootstrap/esm/Button";
import type { OverlayInjectedProps } from "react-bootstrap/esm/Overlay";
import Tooltip from "react-bootstrap/esm/Tooltip";

interface MovieDetailsButtonProps {
  model: MovieCardModel;
}

function MovieDetailsButton({ model }: Readonly<MovieDetailsButtonProps>) {
  const renderTooltip = (text: string, props: OverlayInjectedProps) => (
    <Tooltip id="button-tooltip" {...props}>
      {text}
    </Tooltip>
  );

  return (
    <OverlayTrigger
      placement="top"
      delay={{ show: 200, hide: 50 }}
      overlay={(props) => renderTooltip("About the movie", props)}
    >
      <Button variant="primary" className="btn-sm ms-2">
        <i className="bi bi-info-circle-fill"></i>
      </Button>
    </OverlayTrigger>
  );
}

export default MovieDetailsButton;
