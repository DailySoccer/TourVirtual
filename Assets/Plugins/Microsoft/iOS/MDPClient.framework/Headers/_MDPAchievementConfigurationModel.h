//
//  _MDPAchievementConfigurationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPAchievementConfigurationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPAchievementConfigurationModelAttributes {
	__unsafe_unretained NSString *backgroundImageUrl;
	__unsafe_unretained NSString *expirationDate;
	__unsafe_unretained NSString *game;
	__unsafe_unretained NSString *idAchievement;
	__unsafe_unretained NSString *idGroup;
	__unsafe_unretained NSString *idType;
	__unsafe_unretained NSString *imageUrl;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *level;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *points;
	__unsafe_unretained NSString *virtualGoods;
} MDPAchievementConfigurationModelAttributes;

extern const struct MDPAchievementConfigurationModelRelationships {
	__unsafe_unretained NSString *descriptionAchievementConfiguration;
	__unsafe_unretained NSString *levelName;
	__unsafe_unretained NSString *rules;
} MDPAchievementConfigurationModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;
@class MDPRuleConfigurationModel;

@interface _MDPAchievementConfigurationModel : NSManagedObject

@property (nonatomic, strong) NSString* backgroundImageUrl;

//- (BOOL)validateBackgroundImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* expirationDate;

//- (BOOL)validateExpirationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* game;

@property (atomic) int64_t gameValue;
- (int64_t)gameValue;
- (void)setGameValue:(int64_t)value_;

//- (BOOL)validateGame:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAchievement;

//- (BOOL)validateIdAchievement:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idGroup;

//- (BOOL)validateIdGroup:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idType;

//- (BOOL)validateIdType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* imageUrl;

//- (BOOL)validateImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* level;

@property (atomic) uint64_t levelValue;
- (uint64_t)levelValue;
- (void)setLevelValue:(uint64_t)value_;

//- (BOOL)validateLevel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* points;

@property (atomic) int64_t pointsValue;
- (int64_t)pointsValue;
- (void)setPointsValue:(int64_t)value_;

//- (BOOL)validatePoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* virtualGoods;

//- (BOOL)validateVirtualGoods:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionAchievementConfiguration;

- (NSMutableSet*)descriptionAchievementConfigurationSet;

@property (nonatomic, strong) NSSet *levelName;

- (NSMutableSet*)levelNameSet;

@property (nonatomic, strong) NSSet *rules;

- (NSMutableSet*)rulesSet;

@end

@interface _MDPAchievementConfigurationModel (DescriptionAchievementConfigurationCoreDataGeneratedAccessors)
- (void)addDescriptionAchievementConfiguration:(NSSet*)value_;
- (void)removeDescriptionAchievementConfiguration:(NSSet*)value_;
- (void)addDescriptionAchievementConfigurationObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionAchievementConfigurationObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPAchievementConfigurationModel (LevelNameCoreDataGeneratedAccessors)
- (void)addLevelName:(NSSet*)value_;
- (void)removeLevelName:(NSSet*)value_;
- (void)addLevelNameObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeLevelNameObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPAchievementConfigurationModel (RulesCoreDataGeneratedAccessors)
- (void)addRules:(NSSet*)value_;
- (void)removeRules:(NSSet*)value_;
- (void)addRulesObject:(MDPRuleConfigurationModel*)value_;
- (void)removeRulesObject:(MDPRuleConfigurationModel*)value_;
@end

@interface _MDPAchievementConfigurationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveBackgroundImageUrl;
- (void)setPrimitiveBackgroundImageUrl:(NSString*)value;

- (NSDate*)primitiveExpirationDate;
- (void)setPrimitiveExpirationDate:(NSDate*)value;

- (NSNumber*)primitiveGame;
- (void)setPrimitiveGame:(NSNumber*)value;

- (int64_t)primitiveGameValue;
- (void)setPrimitiveGameValue:(int64_t)value_;

- (NSString*)primitiveIdAchievement;
- (void)setPrimitiveIdAchievement:(NSString*)value;

- (NSString*)primitiveIdGroup;
- (void)setPrimitiveIdGroup:(NSString*)value;

- (NSString*)primitiveIdType;
- (void)setPrimitiveIdType:(NSString*)value;

- (NSString*)primitiveImageUrl;
- (void)setPrimitiveImageUrl:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveLevel;
- (void)setPrimitiveLevel:(NSNumber*)value;

- (uint64_t)primitiveLevelValue;
- (void)setPrimitiveLevelValue:(uint64_t)value_;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitivePoints;
- (void)setPrimitivePoints:(NSNumber*)value;

- (int64_t)primitivePointsValue;
- (void)setPrimitivePointsValue:(int64_t)value_;

- (NSData*)primitiveVirtualGoods;
- (void)setPrimitiveVirtualGoods:(NSData*)value;

- (NSMutableSet*)primitiveDescriptionAchievementConfiguration;
- (void)setPrimitiveDescriptionAchievementConfiguration:(NSMutableSet*)value;

- (NSMutableSet*)primitiveLevelName;
- (void)setPrimitiveLevelName:(NSMutableSet*)value;

- (NSMutableSet*)primitiveRules;
- (void)setPrimitiveRules:(NSMutableSet*)value;

@end
