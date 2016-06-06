//
//  _MDPGamificationStatusModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPGamificationStatusModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPGamificationStatusModelAttributes {
	__unsafe_unretained NSString *achievements;
	__unsafe_unretained NSString *challenges;
	__unsafe_unretained NSString *checkIns;
	__unsafe_unretained NSString *friends;
	__unsafe_unretained NSString *gamingScore;
	__unsafe_unretained NSString *groups;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *level;
	__unsafe_unretained NSString *levelNumber;
	__unsafe_unretained NSString *points;
	__unsafe_unretained NSString *reputation;
	__unsafe_unretained NSString *virtualGoods;
} MDPGamificationStatusModelAttributes;

@interface _MDPGamificationStatusModel : NSManagedObject

@property (nonatomic, strong) NSNumber* achievements;

@property (atomic) int64_t achievementsValue;
- (int64_t)achievementsValue;
- (void)setAchievementsValue:(int64_t)value_;

//- (BOOL)validateAchievements:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* challenges;

@property (atomic) int64_t challengesValue;
- (int64_t)challengesValue;
- (void)setChallengesValue:(int64_t)value_;

//- (BOOL)validateChallenges:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* checkIns;

@property (atomic) int64_t checkInsValue;
- (int64_t)checkInsValue;
- (void)setCheckInsValue:(int64_t)value_;

//- (BOOL)validateCheckIns:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* friends;

@property (atomic) int64_t friendsValue;
- (int64_t)friendsValue;
- (void)setFriendsValue:(int64_t)value_;

//- (BOOL)validateFriends:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* gamingScore;

@property (atomic) int64_t gamingScoreValue;
- (int64_t)gamingScoreValue;
- (void)setGamingScoreValue:(int64_t)value_;

//- (BOOL)validateGamingScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* groups;

@property (atomic) int64_t groupsValue;
- (int64_t)groupsValue;
- (void)setGroupsValue:(int64_t)value_;

//- (BOOL)validateGroups:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* level;

//- (BOOL)validateLevel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* levelNumber;

@property (atomic) int64_t levelNumberValue;
- (int64_t)levelNumberValue;
- (void)setLevelNumberValue:(int64_t)value_;

//- (BOOL)validateLevelNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* points;

@property (atomic) int64_t pointsValue;
- (int64_t)pointsValue;
- (void)setPointsValue:(int64_t)value_;

//- (BOOL)validatePoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* reputation;

@property (atomic) int64_t reputationValue;
- (int64_t)reputationValue;
- (void)setReputationValue:(int64_t)value_;

//- (BOOL)validateReputation:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* virtualGoods;

@property (atomic) int64_t virtualGoodsValue;
- (int64_t)virtualGoodsValue;
- (void)setVirtualGoodsValue:(int64_t)value_;

//- (BOOL)validateVirtualGoods:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPGamificationStatusModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAchievements;
- (void)setPrimitiveAchievements:(NSNumber*)value;

- (int64_t)primitiveAchievementsValue;
- (void)setPrimitiveAchievementsValue:(int64_t)value_;

- (NSNumber*)primitiveChallenges;
- (void)setPrimitiveChallenges:(NSNumber*)value;

- (int64_t)primitiveChallengesValue;
- (void)setPrimitiveChallengesValue:(int64_t)value_;

- (NSNumber*)primitiveCheckIns;
- (void)setPrimitiveCheckIns:(NSNumber*)value;

- (int64_t)primitiveCheckInsValue;
- (void)setPrimitiveCheckInsValue:(int64_t)value_;

- (NSNumber*)primitiveFriends;
- (void)setPrimitiveFriends:(NSNumber*)value;

- (int64_t)primitiveFriendsValue;
- (void)setPrimitiveFriendsValue:(int64_t)value_;

- (NSNumber*)primitiveGamingScore;
- (void)setPrimitiveGamingScore:(NSNumber*)value;

- (int64_t)primitiveGamingScoreValue;
- (void)setPrimitiveGamingScoreValue:(int64_t)value_;

- (NSNumber*)primitiveGroups;
- (void)setPrimitiveGroups:(NSNumber*)value;

- (int64_t)primitiveGroupsValue;
- (void)setPrimitiveGroupsValue:(int64_t)value_;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveLevel;
- (void)setPrimitiveLevel:(NSString*)value;

- (NSNumber*)primitiveLevelNumber;
- (void)setPrimitiveLevelNumber:(NSNumber*)value;

- (int64_t)primitiveLevelNumberValue;
- (void)setPrimitiveLevelNumberValue:(int64_t)value_;

- (NSNumber*)primitivePoints;
- (void)setPrimitivePoints:(NSNumber*)value;

- (int64_t)primitivePointsValue;
- (void)setPrimitivePointsValue:(int64_t)value_;

- (NSNumber*)primitiveReputation;
- (void)setPrimitiveReputation:(NSNumber*)value;

- (int64_t)primitiveReputationValue;
- (void)setPrimitiveReputationValue:(int64_t)value_;

- (NSNumber*)primitiveVirtualGoods;
- (void)setPrimitiveVirtualGoods:(NSNumber*)value;

- (int64_t)primitiveVirtualGoodsValue;
- (void)setPrimitiveVirtualGoodsValue:(int64_t)value_;

@end
