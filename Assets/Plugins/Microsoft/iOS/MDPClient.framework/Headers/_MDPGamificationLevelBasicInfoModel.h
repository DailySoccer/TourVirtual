//
//  _MDPGamificationLevelBasicInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPGamificationLevelBasicInfoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPGamificationLevelBasicInfoModelAttributes {
	__unsafe_unretained NSString *appId;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *levelNumber;
	__unsafe_unretained NSString *maxLevel;
	__unsafe_unretained NSString *minLevel;
} MDPGamificationLevelBasicInfoModelAttributes;

extern const struct MDPGamificationLevelBasicInfoModelRelationships {
	__unsafe_unretained NSString *name;
} MDPGamificationLevelBasicInfoModelRelationships;

@class MDPLocaleDescriptionModel;

@interface _MDPGamificationLevelBasicInfoModel : NSManagedObject

@property (nonatomic, strong) NSString* appId;

//- (BOOL)validateAppId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* levelNumber;

@property (atomic) uint64_t levelNumberValue;
- (uint64_t)levelNumberValue;
- (void)setLevelNumberValue:(uint64_t)value_;

//- (BOOL)validateLevelNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* maxLevel;

@property (atomic) uint64_t maxLevelValue;
- (uint64_t)maxLevelValue;
- (void)setMaxLevelValue:(uint64_t)value_;

//- (BOOL)validateMaxLevel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* minLevel;

@property (atomic) uint64_t minLevelValue;
- (uint64_t)minLevelValue;
- (void)setMinLevelValue:(uint64_t)value_;

//- (BOOL)validateMinLevel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *name;

- (NSMutableSet*)nameSet;

@end

@interface _MDPGamificationLevelBasicInfoModel (NameCoreDataGeneratedAccessors)
- (void)addName:(NSSet*)value_;
- (void)removeName:(NSSet*)value_;
- (void)addNameObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeNameObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPGamificationLevelBasicInfoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAppId;
- (void)setPrimitiveAppId:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveLevelNumber;
- (void)setPrimitiveLevelNumber:(NSNumber*)value;

- (uint64_t)primitiveLevelNumberValue;
- (void)setPrimitiveLevelNumberValue:(uint64_t)value_;

- (NSNumber*)primitiveMaxLevel;
- (void)setPrimitiveMaxLevel:(NSNumber*)value;

- (uint64_t)primitiveMaxLevelValue;
- (void)setPrimitiveMaxLevelValue:(uint64_t)value_;

- (NSNumber*)primitiveMinLevel;
- (void)setPrimitiveMinLevel:(NSNumber*)value;

- (uint64_t)primitiveMinLevelValue;
- (void)setPrimitiveMinLevelValue:(uint64_t)value_;

- (NSMutableSet*)primitiveName;
- (void)setPrimitiveName:(NSMutableSet*)value;

@end
