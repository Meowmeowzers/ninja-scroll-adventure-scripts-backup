public enum CharacterState {
    Idle, 
    Moving, 
    Attacking,
    KO
}

public enum DamageType {
    MeleePhysical,
    RangedPhysical,
    Fire,
    Ice,
    Lightning,
    Magical,
    Unknown
}

public enum GameState {
    MainMenu, 
    Ingame, 
    Paused, 
    GameOver
}

public enum InputMode
{
    Keyboard,
    Touch
}
