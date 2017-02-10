//
//  _MDPTeamOfficialModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTeamOfficialModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTeamOfficialModelAttributes {
	__unsafe_unretained NSString *birthDate;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *idTeamOfficial;
	__unsafe_unretained NSString *joinDate;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *teamOfficialType;
} MDPTeamOfficialModelAttributes;

extern const struct MDPTeamOfficialModelRelationships {
	__unsafe_unretained NSString *teamOfficials;
} MDPTeamOfficialModelRelationships;

@class MDPTeamModel;

@interface _MDPTeamOfficialModel : NSManagedObject

@property (nonatomic, strong) NSDate* birthDate;

//- (BOOL)validateBirthDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeamOfficial;

//- (BOOL)validateIdTeamOfficial:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* joinDate;

//- (BOOL)validateJoinDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* teamOfficialType;

@property (atomic) uint16_t teamOfficialTypeValue;
- (uint16_t)teamOfficialTypeValue;
- (void)setTeamOfficialTypeValue:(uint16_t)value_;

//- (BOOL)validateTeamOfficialType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *teamOfficials;

- (NSMutableSet*)teamOfficialsSet;

@end

@interface _MDPTeamOfficialModel (TeamOfficialsCoreDataGeneratedAccessors)
- (void)addTeamOfficials:(NSSet*)value_;
- (void)removeTeamOfficials:(NSSet*)value_;
- (void)addTeamOfficialsObject:(MDPTeamModel*)value_;
- (void)removeTeamOfficialsObject:(MDPTeamModel*)value_;
@end

@interface _MDPTeamOfficialModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveBirthDate;
- (void)setPrimitiveBirthDate:(NSDate*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSString*)primitiveIdTeamOfficial;
- (void)setPrimitiveIdTeamOfficial:(NSString*)value;

- (NSDate*)primitiveJoinDate;
- (void)setPrimitiveJoinDate:(NSDate*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitiveTeamOfficialType;
- (void)setPrimitiveTeamOfficialType:(NSNumber*)value;

- (uint16_t)primitiveTeamOfficialTypeValue;
- (void)setPrimitiveTeamOfficialTypeValue:(uint16_t)value_;

- (NSMutableSet*)primitiveTeamOfficials;
- (void)setPrimitiveTeamOfficials:(NSMutableSet*)value;

@end
