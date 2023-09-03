import {
  createSlice,
  PayloadAction,
} from '@reduxjs/toolkit';

export type ShopTower = {
  id: string;
};
type InitialState = {
  shopTowerSelected?: ShopTower;
};

const initialState: InitialState = {
  shopTowerSelected: undefined,
};

export const gameLayoutSlice = createSlice({
  name: 'gameLayout',
  initialState,
  reducers: {
    setSelectedShopTower: (
      state,
      action: PayloadAction<ShopTower>,
    ) => {
      state.shopTowerSelected = {
        id: action.payload.id,
      };
    },
  },
});

export const { setSelectedShopTower } = gameLayoutSlice.actions;
export default gameLayoutSlice.reducer;
