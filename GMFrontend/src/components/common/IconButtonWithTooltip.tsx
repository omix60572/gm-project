import Button from "react-bootstrap/esm/Button";
import type { OverlayInjectedProps } from "react-bootstrap/esm/Overlay";
import OverlayTrigger from "react-bootstrap/esm/OverlayTrigger";
import Tooltip from "react-bootstrap/esm/Tooltip";

interface IconButtonWithTooltipProps {
  text: string;
  placement?: "top" | "right" | "bottom" | "left";
  onButtonClick: () => void;
  buttonColor:
    | "primary"
    | "secondary"
    | "success"
    | "danger"
    | "warning"
    | "info"
    | "light"
    | "dark"
    | "link";
  buttonClass?: string;
  buttonIconClass: string;
}

function IconButtonWithTooltip({
  text,
  placement,
  onButtonClick,
  buttonColor,
  buttonClass,
  buttonIconClass,
}: Readonly<IconButtonWithTooltipProps>) {
  const tooltipPlacement = placement ?? "top";
  const buttonClasses =
    buttonClass !== null && buttonClass !== undefined && buttonClass.length > 0
      ? `btn-sm ${buttonClass}`
      : "btn-sm";
  const buttonIcon = `bi ${buttonIconClass}`;

  const renderTooltip = (text: string, props: OverlayInjectedProps) => (
    <Tooltip id="button-tooltip" {...props}>
      {text}
    </Tooltip>
  );

  return (
    <OverlayTrigger
      placement={tooltipPlacement}
      delay={{ show: 200, hide: 50 }}
      overlay={(props) => renderTooltip(text, props)}
    >
      <Button
        variant={buttonColor}
        className={buttonClasses}
        onClick={onButtonClick}
      >
        <i className={buttonIcon}></i>
      </Button>
    </OverlayTrigger>
  );
}

export default IconButtonWithTooltip;
