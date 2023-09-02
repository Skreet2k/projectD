import { useEffect, useState } from 'react';
import {
  FieldObject, InitialField, Position, Row, UseFieldProps,
} from './PayingField.types';

const getSizes = (heightAmount: number) => ({
  sizeOfField: {
    width: window.innerWidth,
    height: window.innerHeight,
  },
  sizeOfFieldCell: window.innerHeight / heightAmount,
});

interface InitialFieldOptions {
  path: Position[]
  widthAmount: number
  heightAmount: number
  sizeOfFieldCell: number
}

const getInitialFieldObject = ({
  widthAmount,
  heightAmount,
  sizeOfFieldCell,
  path,
}: InitialFieldOptions): FieldObject => {
  const obj: FieldObject = {
    rows: [],
  };
  const minCenterPx = sizeOfFieldCell / 2;
  for (let i = 0; i < heightAmount; i++) {
    const row: Row = {
      cells: [],
      id: `row-${i}`,
    };
    for (let j = 0; j < widthAmount; j++) {
      row.cells.push({
        position: {
          x: j,
          y: i,
        },
        centerPx: {
          xPx: minCenterPx + j * sizeOfFieldCell,
          yPx: minCenterPx + i * sizeOfFieldCell,
        },
        isPath: false,
      });
    }
    obj.rows.push(row);
  }

  path.forEach((item) => {
    obj.rows[item.y].cells[item.x].isPath = true;
  });
  return obj;
};

export const useFieldParams = (
  { widthAmount, heightAmount, path }: UseFieldProps,
): InitialField => {
  const [initialFieldProps, setInitialFieldProps] = useState<InitialField>({
    initialObject: null,
    sizes: {
      sizeOfFieldCell: 0,
    },
  });

  useEffect(() => {
    const sizes = getSizes(heightAmount);
    setInitialFieldProps({
      initialObject: getInitialFieldObject({
        path, widthAmount, heightAmount, sizeOfFieldCell: sizes.sizeOfFieldCell,
      }),
      sizes,
    });
  }, [widthAmount, heightAmount, path]);

  return initialFieldProps;
};
