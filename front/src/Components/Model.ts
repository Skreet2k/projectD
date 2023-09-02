const complexity = {
    1: {
        value: 1,
        code: "EASYN",
    },
    2: {
        value: 2,
        code: "EASY",
    },
};

enum Complexity {
    "ESYAN"="Изян",
    "EASY"="Изя"
}

interface Structure {
    frontend?: {
        value: number,
        parallelWork: true,
    },
    backend?: number,
    scramMaster?: number,
    //TODO дописать всех героев
}

interface Cell {
    x: number,
    y: number,
}

interface Enemy {
    complexity: number; //1-15
    structure: Structure;
    price: {
        value: number,
        // strategy of payment in future
    }
    speed: number,
}
// не пропусти ни одну фичу не сделанной

enum Heroes {
  FE = 'frontend',
  BE = "backend",
};

export interface Wawe {
    enemies: Enemy[],
    // No MVP
    // restrictions: {
    //     heroes: Heroes[],
    // }
}

export interface GameLavel {
    wawes: Wawe[],
    money: {
        startValue: number,
        // bonuses: ["GOALCODE"] no MVP
    }
    road: Cell[],
}
