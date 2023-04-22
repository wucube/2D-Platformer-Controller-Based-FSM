### 项目简介

基于状态机实现土狼时间、空中二段跳、下落时的跳跃预输入。

使用范围检测玩家是否在地面上，避免无限空中跳。实现根据按键时长控制跳跃高度。

角色的移动与停止都有相应的加速减速过程。

使用 `Animator.CrossFade` 切换动画，避免在Animator中设置过渡条件，更加灵活。 

应用观察者模式，角色碰到宝石后弹出胜利画面，实现事件通知引起的关注事件的对象的变化，并解耦相关类，使相关类没有互相持有。

动画事件使用，实现准备界面的动画播放完成后，角色才能开始闯关。

基于ScriptableObject创建大量使用的事件频道类，避免大量重复创建相同的脚本实例。

InputSystem新输入系统的使用。检测玩家的输入，作为状态切换的判断条件。

使用刚体模拟角色的位移效果，结合动画曲线，控制人物的下落速度。

### 运行环境
Unity 2021.3.23f1c1(LTS)
