//
//  _MDPFanAchievementConfigurationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFanAchievementConfigurationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFanAchievementConfigurationModelAttributes {
	__unsafe_unretained NSString *achievedDate;
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
	__unsafe_unretained NSString *ownedByFan;
	__unsafe_unretained NSString *points;
	__unsafe_unretained NSString *url;
	__unsafe_unretained NSString *virtualGoods;
} MDPFanAchievementConfigurationModelAttributes;

extern const struct MDPFanAchievementConfigurationModelRelationships {
	__unsafe_unretained NSString *descriptionfanAchievementConfiguration;
	__unsafe_unretained NSString *fanAchievementConfigurationRequest;
	__unsafe_unretained NSString *levelName;
	__unsafe_unretained NSString *rules;
} MDPFanAchievementConfigurationModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPFanAchievementConfigurationRequestModel;
@class MDPLocaleDescriptionModel;
@class MDPRuleConfigurationModel;

@interface _MDPFanAchievementConfigurationModel : NSManagedObject

@property (nonatomic, strong) NSDate* achievedDate;

//- (BOOL)validateAchievedDate:(id*)value_ error:(NSError**)error_;

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

@property (atomic) int64_t levelValue;
- (int64_t)levelValue;
- (void)setLevelValue:(int64_t)value_;

//- (BOOL)validateLevel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* ownedByFan;

@property (atomic) BOOL ownedByFanValue;
- (BOOL)ownedByFanValue;
- (void)setOwnedByFanValue:(BOOL)value_;

//- (BOOL)validateOwnedByFan:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* points;

@property (atomic) int64_t pointsValue;
- (int64_t)pointsValue;
- (void)setPointsValue:(int64_t)value_;

//- (BOOL)validatePoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* url;

//- (BOOL)validateUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* virtualGoods;

//- (BOOL)validateVirtualGoods:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionfanAchievementConfiguration;

- (NSMutableSet*)descriptionfanAchievementConfigurationSet;

@property (nonatomic, strong) NSSet *fanAchievementConfigurationRequest;

- (NSMutableSet*)fanAchievementConfigurationRequestSet;

@property (nonatomic, strong) NSSet *levelName;

- (NSMutableSet*)levelNameSet;

@property (nonatomic, strong) NSSet *rules;

- (NSMutableSet*)rulesSet;

@end

@interface _MDPFanAchievementConfigurationModel (DescriptionfanAchievementConfigurationCoreDataGeneratedAccessors)
- (void)addDescriptionfanAchievementConfiguration:(NSSet*)value_;
- (void)removeDescriptionfanAchievementConfiguration:(NSSet*)value_;
- (void)addDescriptionfanAchievementConfigurationObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionfanAchievementConfigurationObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFanAchievementConfigurationModel (FanAchievementConfigurationRequestCoreDataGeneratedAccessors)
- (void)addFanAchievementConfigurationRequest:(NSSet*)value_;
- (void)removeFanAchievementConfigurationRequest:(NSSet*)value_;
- (void)addFanAchievementConfigurationRequestObject:(MDPFanAchievementConfigurationRequestModel*)value_;
- (void)removeFanAchievementConfigurationRequestObject:(MDPFanAchievementConfigurationRequestModel*)value_;
@end

@interface _MDPFanAchievementConfigurationModel (LevelNameCoreDataGeneratedAccessors)
- (void)addLevelName:(NSSet*)value_;
- (void)removeLevelName:(NSSet*)value_;
- (void)addLevelNameObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeLevelNameObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFanAchievementConfigurationModel (RulesCoreDataGeneratedAccessors)
- (void)addRules:(NSSet*)value_;
- (void)removeRules:(NSSet*)value_;
- (void)addRulesObject:(MDPRuleConfigurationModel*)value_;
- (void)removeRulesObject:(MDPRuleConfigurationModel*)value_;
@end

@interface _MDPFanAchievementConfigurationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveAchievedDate;
- (void)setPrimitiveAchievedDate:(NSDate*)value;

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

- (int64_t)primitiveLevelValue;
- (void)setPrimitiveLevelValue:(int64_t)value_;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitiveOwnedByFan;
- (void)setPrimitiveOwnedByFan:(NSNumber*)value;

- (BOOL)primitiveOwnedByFanValue;
- (void)setPrimitiveOwnedByFanValue:(BOOL)value_;

- (NSNumber*)primitivePoints;
- (void)setPrimitivePoints:(NSNumber*)value;

- (int64_t)primitivePointsValue;
- (void)setPrimitivePointsValue:(int64_t)value_;

- (NSString*)primitiveUrl;
- (void)setPrimitiveUrl:(NSString*)value;

- (NSData*)primitiveVirtualGoods;
- (void)setPrimitiveVirtualGoods:(NSData*)value;

- (NSMutableSet*)primitiveDescriptionfanAchievementConfiguration;
- (void)setPrimitiveDescriptionfanAchievementConfiguration:(NSMutableSet*)value;

- (NSMutableSet*)primitiveFanAchievementConfigurationRequest;
- (void)setPrimitiveFanAchievementConfigurationRequest:(NSMutableSet*)value;

- (NSMutableSet*)primitiveLevelName;
- (void)setPrimitiveLevelName:(NSMutableSet*)value;

- (NSMutableSet*)primitiveRules;
- (void)setPrimitiveRules:(NSMutableSet*)value;

@end
