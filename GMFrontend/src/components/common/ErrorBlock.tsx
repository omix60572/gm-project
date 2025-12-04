interface ErrorBlockProps {
  text: string;
}

function ErrorBlock({ text }: Readonly<ErrorBlockProps>) {
  return (
    <div className="mt-3 mb-3 p-3 text-danger-emphasis bg-danger-subtle border border-danger-subtle rounded-2">
      <span>{text}</span>
    </div>
  );
}

export default ErrorBlock;
