import { createSlice } from '@reduxjs/toolkit';

type CounterState = {
  value: number;
};
export const counterSlice = createSlice({
  name: 'counter',
  initialState: <CounterState>{
    value: 0,
  },
  reducers: {
    increment: (state) => ({
      ...state,
      value: state.value + 1,
    }),
  },
});

export const { increment } = counterSlice.actions;

// export const incrementAsync = (amount: any) => (dispatch: (arg0: { payload: any; type: string; }) => void) => {
//   setTimeout(() => {
//     dispatch(incrementByAmount(amount));
//   }, 1000);
// };

export const selectCount = (state: { counter: { value: any; }; }) => state.counter.value;

export default counterSlice.reducer;
