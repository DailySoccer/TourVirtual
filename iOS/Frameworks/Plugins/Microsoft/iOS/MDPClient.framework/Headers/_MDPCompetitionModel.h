//
//  _MDPCompetitionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCompetitionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCompetitionModelAttributes {
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *processRanking;
	__unsafe_unretained NSString *type;
	__unsafe_unretained NSString *videoPlatformName;
} MDPCompetitionModelAttributes;

extern const struct MDPCompetitionModelRelationships {
	__unsafe_unretained NSString *name;
} MDPCompetitionModelRelationships;

@class MDPLocaleDescriptionModel;

@interface _MDPCompetitionModel : NSManagedObject

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* processRanking;

@property (atomic) BOOL processRankingValue;
- (BOOL)processRankingValue;
- (void)setProcessRankingValue:(BOOL)value_;

//- (BOOL)validateProcessRanking:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* type;

@property (atomic) int16_t typeValue;
- (int16_t)typeValue;
- (void)setTypeValue:(int16_t)value_;

//- (BOOL)validateType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* videoPlatformName;

//- (BOOL)validateVideoPlatformName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *name;

- (NSMutableSet*)nameSet;

@end

@interface _MDPCompetitionModel (NameCoreDataGeneratedAccessors)
- (void)addName:(NSSet*)value_;
- (void)removeName:(NSSet*)value_;
- (void)addNameObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeNameObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPCompetitionModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveProcessRanking;
- (void)setPrimitiveProcessRanking:(NSNumber*)value;

- (BOOL)primitiveProcessRankingValue;
- (void)setPrimitiveProcessRankingValue:(BOOL)value_;

- (NSNumber*)primitiveType;
- (void)setPrimitiveType:(NSNumber*)value;

- (int16_t)primitiveTypeValue;
- (void)setPrimitiveTypeValue:(int16_t)value_;

- (NSString*)primitiveVideoPlatformName;
- (void)setPrimitiveVideoPlatformName:(NSString*)value;

- (NSMutableSet*)primitiveName;
- (void)setPrimitiveName:(NSMutableSet*)value;

@end
