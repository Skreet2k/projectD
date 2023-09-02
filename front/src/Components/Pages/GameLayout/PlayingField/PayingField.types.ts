export type CoordinatePx = {
  xPx: number;
  yPx: number;
};

export type Position = {
  x: number;
  y: number;
};

export type UseFieldProps = {
  widthAmount: number;
  heightAmount: number;
  path: Position[];
};
export interface Cell {
  position: Position;
  centerPx: CoordinatePx;
  isPath?: boolean;
}

export interface Row {
  id: string;
  cells: Cell[];
}

export interface FieldObject {
  rows: Row[],
}

export interface Sizes {
  sizeOfField?: {
    width: number;
    height: number;
  };
  sizeOfFieldCell: number;
}

export interface InitialField {
  initialObject: FieldObject | null;
  sizes: Sizes;
}
